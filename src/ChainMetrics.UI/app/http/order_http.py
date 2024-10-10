import requests
import streamlit as st

from typing import Optional
from config.settings import API_URL

from app.types.page import Page


@st.cache_data
def get_orders(_filter: Optional[Page]):
    req = requests.get(API_URL + "Order", params=_filter.model_dump())
    if not req.ok:
        return None
    return req.json()


@st.cache_data
def get_orders_by_status():
    req = requests.get(API_URL + "Order/per-status")
    if not req.ok:
        return None
    return req.json()


@st.cache_data
def get_orders_by_purchase_date():
    req = requests.get(API_URL + "Order/per-purchase")
    if not req.ok:
        return None
    return req.json()
