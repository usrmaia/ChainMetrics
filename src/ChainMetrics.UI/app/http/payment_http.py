import requests
import streamlit as st

from typing import Optional
from config.settings import API_URL

from app.types.page import Page


@st.cache_data
def get_payments(_filter: Optional[Page]):
    req = requests.get(API_URL + "Payment", params=_filter.model_dump())
    if not req.ok:
        return None
    return req.json()


@st.cache_data
def get_payments_by_type():
    req = requests.get(API_URL + "Payment/per-type")
    if not req.ok:
        return None
    return req.json()


@st.cache_data
def get_payments_by_installments():
    req = requests.get(API_URL + "Payment/per-installments")
    if not req.ok:
        return None
    return req.json()
