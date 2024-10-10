import requests
import streamlit as st

from typing import Optional

from config.settings import API_URL
from app.types.page import Page


@st.cache_data
def get_customers(_filter: Optional[Page]):
    req = requests.get(API_URL + "Customer", params=_filter.model_dump())
    if not req.ok:
        return None
    return req.json()


@st.cache_data
def get_top_expensive_customers(top: int = 20):
    req = requests.get(API_URL + "Customer/top-expensive", params={"top": top})
    if not req.ok:
        return None
    return req.json()


@st.cache_data
def get_customers_by_state():
    req = requests.get(API_URL + "Customer/per-state")
    if not req.ok:
        return None
    return req.json()


@st.cache_data
def get_customers_by_city(top: int = 20):
    req = requests.get(API_URL + "Customer/per-city", params={"top": top})
    if not req.ok:
        return None
    return req.json()
