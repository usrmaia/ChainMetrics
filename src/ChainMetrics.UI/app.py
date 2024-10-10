import streamlit as st

from app.components.toggle_theme_button import get_theme
from app.layout.base_layout import set_layout
from app.navigation.navigation import navigation

set_layout()

st.logo(
    image="static/title-logo-dark.svg" if get_theme() == "dark" else "static/title-logo-light.svg",
    icon_image="static/logo.svg",
    link="https://github.com/usrmaia/ChainMetrics",
)

navigation()
