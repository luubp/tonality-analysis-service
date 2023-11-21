from fastapi import FastAPI
from pydantic import BaseModel
from contextlib import asynccontextmanager

from app.core_ml.model import load_model


model = None

class SentimentResponse(BaseModel):
    text: str
    sentiment_label: str
    sentiment_score: float

@asynccontextmanager
async def lifespan(app: FastAPI):
    # Load the ML model
    global model
    model = load_model()
    yield
    model.clear()

app = FastAPI(lifespan=lifespan)

# create a route
@app.get("/")
def index():
    return {"text": "Sentiment Analysis"}

@app.get("/predict")
def predict_sentiment(text: str) -> SentimentResponse:
    sentiment = model(text)

    response = SentimentResponse(
        text=text,
        sentiment_label=sentiment.label,
        sentiment_score=sentiment.score,
    )

    return response