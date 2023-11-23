from fastapi import FastAPI
from pydantic import BaseModel
from contextlib import asynccontextmanager

from app.core_ml.model import load_model


model = None

class SentimentResponse(BaseModel):
    text: str
    label_1: str
    score_1: float
    label_2: str
    score_2: float
    label_3: str
    score_3: float

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
        label_1=sentiment.label_1,
        score_1=sentiment.score_1,
        label_2=sentiment.label_2,
        score_2=sentiment.score_2,
        label_3=sentiment.label_3,
        score_3=sentiment.score_3,
    )

    return response