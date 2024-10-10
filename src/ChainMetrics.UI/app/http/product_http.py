import requests
import streamlit as st

from typing import Optional
from config.settings import API_URL

from app.types.product import Product


@st.cache_data
def get_products(_filter: Optional[Product]):
    req = requests.get(API_URL + "Product", params=_filter.model_dump())
    if not req.ok:
        return None
    return req.json()


@st.cache_data
def get_products_by_category():
    req = requests.get(API_URL + "Product/per-category")
    if not req.ok:
        return None
    return req.json()
