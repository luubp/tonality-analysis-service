from dataclasses import dataclass
from pathlib import Path

import yaml
from transformers import pipeline

# load config file
config_path = Path(__file__).parent / "config.yaml"
with open(config_path, "r") as file:
    config = yaml.load(file, Loader=yaml.FullLoader)

@dataclass
class SentimentPrediction:
    """Class representing a sentiment prediction result."""

    label_1: str
    score_1: float
    label_2: str
    score_2: float
    label_3: str
    score_3: float


def load_model():
    """Load a pre-trained sentiment analysis model.

    Returns:
        model (function): A function that takes a text input and returns a SentimentPrediction object.
    """
    model_hf = pipeline(config["task"], model=config["model"], device='cpu')

    def model(text: str) -> SentimentPrediction:
        pred = model_hf(text, top_k=None)
        return SentimentPrediction(
            label_1=pred[0]["label"],
            score_1=pred[0]["score"],
            label_2=pred[1]["label"],
            score_2=pred[1]["score"],
            label_3=pred[2]["label"],
            score_3=pred[2]["score"],
        )

    return model