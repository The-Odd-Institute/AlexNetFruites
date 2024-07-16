# Fruit Classification with AlexNet

This repository contains a project for classifying fruits using a pre-trained AlexNet model with PyTorch. The project demonstrates transfer learning by fine-tuning the AlexNet model to classify images of different fruits.

## Table of Contents

- [Introduction](#introduction)
- [Requirements](#requirements)
- [Setup](#setup)
- [Data Preparation](#data-preparation)
- [Training the Model](#training-the-model)
- [Evaluating the Model](#evaluating-the-model)
- [Exporting the Model](#exporting-the-model)
- [Visualizing the Results](#visualizing-the-results)

## Introduction

This project utilizes the AlexNet model, pre-trained on ImageNet, to classify images of fruits. By leveraging transfer learning, we fine-tune the model for our specific task, significantly reducing the time and computational resources needed for training.

## Requirements

- Python 3.6 or higher
- PyTorch
- Torchvision
- scikit-learn
- matplotlib

You can install the required packages using pip:

```bash
pip install torch torchvision scikit-learn matplotlib
```


Clone the repository to your local machine:
```bash
git clone https://github.com/yourusername/fruit-classification-alexnet.git
cd fruit-classification-alexnet
```

Example structure:
data
└── Fruit_Classification
    ├── Apple
    │   ├── image1.jpg
    │   ├── image2.jpg
    │   └── ...
    ├── Banana
    │   ├── image1.jpg
    │   ├── image2.jpg
    │   └── ...
    └── ...

    

