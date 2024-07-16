using UnityEngine;
using Unity.Barracuda;
using UnityEngine.UI;


// Install from com.unity.barracuda

public class AlexNetFruiteClassification : MonoBehaviour
{
    [SerializeField] NNModel modelAsset;
    private IWorker worker;

    [SerializeField] Texture2D texture; 

    [SerializeField] Image imageSample;
    
    private Sprite TextureToSprite(Texture2D texture)
    {
        // Create a new sprite from the texture
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        Vector2 pivot = new Vector2(0.5f, 0.5f); // Set the pivot to the center
        Sprite sprite = Sprite.Create(texture, rect, pivot);

        return sprite;
    }

    void Start()
    {
        var model = ModelLoader.Load(modelAsset);

        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.ComputePrecompiled, model);


        // convert texture to sprite
        Sprite sprite = TextureToSprite(texture);
        imageSample.sprite = sprite;

    }

    public void Classify()
    {
        // Preprocess the image to the correct size
        Texture2D resizedTexture = ResizeTexture(texture, 224, 224);  

        // Convert the texture to a Tensor
        var input = new Tensor(resizedTexture, 3);  // Adjust channels as per your model

        // Execute the model
        worker.Execute(input);

        // Get the output
        Tensor output = worker.PeekOutput();
        
        // Process the output (e.g., get the class with the highest score)
        float[] scores = output.ToReadOnlyArray();
        int maxIndex = System.Array.IndexOf(scores, Mathf.Max(scores));

        // Map the index to names
        string[] classNames = new string[] { "Apple Braeburn", 
        "Apple Granny Smith", "Apricot", "Avocado", "Banana", "Blueberry", "Cactus fruit", "Cantaloupe", "Cherry", "Clementine", "Corn", "Cucumber Ripe", "Grape Blue", "Kiwi", "Lemon", "Limes", "Mango", "Onion White", "Orange", "Papaya", "Passion Fruit", "Peach", "Pear", "Pepper Green", "Pepper Red", "Pineapple", "Plum", "Pomegranate", "Potato Red", "Raspberry", "Strawberry", "Tomato", "Watermelon" };  // Adjust the names as per your model
        string predictedClass = classNames[maxIndex];



        Debug.Log("Predicted class: " + predictedClass);

        // Dispose tensors
        input.Dispose();
        output.Dispose();
    }

    Texture2D ResizeTexture(Texture2D source, int newWidth, int newHeight)
    {
        RenderTexture rt = new RenderTexture(newWidth, newHeight, 24);
        RenderTexture.active = rt;
        Graphics.Blit(source, rt);
        Texture2D result = new Texture2D(newWidth, newHeight);
        result.ReadPixels(new Rect(0, 0, newWidth, newHeight), 0, 0);
        result.Apply();
        return result;
    }

    void OnDestroy()
    {
        worker.Dispose();
    }
}