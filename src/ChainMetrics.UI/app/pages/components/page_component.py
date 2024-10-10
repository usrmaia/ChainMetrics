import streamlit as st

from app.types.page import Page


def setup_session_state_page(page: int = 1, per_page: int = 100, sort: str = "id", sort_by: int = 0):
    if "page" not in st.session_state:
        st.session_state.page = page
    if "per_page" not in st.session_state:
        st.session_state.per_page = per_page
    if "sort" not in st.session_state:
        st.session_state.sort = sort
    if "sort_by" not in st.session_state:
        st.session_state.sort_by = sort_by


def render_filter_table(page: Page):
    _page, _per_page, _sort, _sort_by = st.columns(4, vertical_alignment="center")

    _page.number_input(
        label="Página",
        key="page",
        min_value=1,
        on_change=page.__setattr__(name="page", value=st.session_state.page),
    )
    _per_page.number_input(
        label="Clientes por Página",
        key="per_page",
        min_value=1,
        on_change=page.__setattr__(name="per_page", value=st.session_state.per_page),
    )
    _sort.text_input(
        label="Ordenar por",
        key="sort",
        on_change=page.__setattr__(name="sort", value=st.session_state.sort),
    )
    _sort_by.selectbox(
        label="Ordem",
        key="sort_by",
        options=[0, 1],
        format_func=lambda x: "Crescente" if x == 0 else "Decrescente",
        on_change=page.__setattr__(name="sort_by", value=st.session_state.sort_by),
    )
