FROM python:3.10

WORKDIR /workdir

COPY app/ /workdir/app/
COPY requirements.txt /workdir/

RUN pip install -r ./requirements.txt

CMD ["uvicorn", "app.main:app", "--host", "0.0.0.0", "--port", "80"]
