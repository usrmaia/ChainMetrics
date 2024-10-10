python -m venv venv
. .\venv\Scripts\activate
deactivate
pip freeze > requirements.txt
pip install -r requirements.txt
streamlit run app.py