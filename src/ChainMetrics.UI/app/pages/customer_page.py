import pandas as pd
import streamlit as st

from app.http.customer_http import (
    get_customers,
    get_customers_by_city,
    get_customers_by_state,
    get_top_expensive_customers,
)
from app.types.page import Page
from app.utils.slug import generate_slug
from app.pages.components.page_component import setup_session_state_page, render_filter_table


def display_customers(page: Page):
    if st.button("Buscar Clientes"):
        customers = get_customers(_filter=page)

        if not customers:
            st.write("Nenhum cliente encontrado.")

        df = pd.DataFrame(customers)
        st.dataframe(df, use_container_width=True)


def display_top_customers():
    top_customers = st.number_input("Top Clientes", min_value=1, value=20)

    if st.button("Buscar Top Clientes"):
        top_customers = get_top_expensive_customers(top=top_customers)

        if top_customers:
            df = pd.DataFrame(top_customers)
            st.dataframe(df)
        else:
            st.write("Nenhum cliente encontrado.")


def display_customers_by_state():
    st.subheader("Clientes por Estado")

    if st.button("Buscar Clientes por Estado"):
        states = get_customers_by_state()

        if not states:
            st.write("Nenhum estado encontrado.")
            return

        df_states = pd.DataFrame(states)
        rows = df_states.shape[0]
        st.dataframe(df_states, height=rows * 36 + 20)
        st.bar_chart(
            df_states,
            x="state",
            x_label="Estado",
            y=["totalPaymentValue", "quantityOrders"],
            y_label=["Valor Total de Compras", "Quantidade de Compras"],
            stack=False,
            use_container_width=True,
        )


def display_customers_by_city():
    st.subheader("Clientes por Cidade")

    top_cities = st.number_input("Top Cidades", min_value=1, value=7)

    if st.button("Buscar Clientes por Cidade"):
        top_cities = get_customers_by_city(top=top_cities)

        if not top_cities:
            st.write("Nenhuma cidade encontrada.")

        latlon = {
            "AC": [-8.77, -70.55],
            "AL": [-9.62, -36.82],
            "AM": [-3.47, -65.10],
            "AP": [1.41, -51.77],
            "BA": [-13.29, -41.71],
            "CE": [-5.20, -39.53],
            "DF": [-15.83, -47.86],
            "ES": [-19.19, -40.34],
            "GO": [-15.98, -49.86],
            "MA": [-5.42, -45.44],
            "MT": [-12.64, -55.42],
            "MS": [-20.51, -54.54],
            "MG": [-18.10, -44.38],
            "PA": [-3.79, -52.48],
            "PB": [-7.28, -36.72],
            "PR": [-24.89, -51.55],
            "PE": [-8.38, -37.86],
            "PI": [-6.60, -42.28],
            "RJ": [-22.25, -42.66],
            "RN": [-5.81, -36.59],
            "RO": [-10.83, -63.34],
            "RS": [-30.17, -53.50],
            "RR": [1.99, -61.33],
            "SC": [-27.45, -50.95],
            "SE": [-10.57, -37.45],
            "SP": [-22.19, -48.79],
            "TO": [-9.46, -48.26],
        }

        df_city = pd.read_csv("data/municipios.csv")

        df = pd.DataFrame(top_cities)
        st.dataframe(df)

        df_city["municipio"] = df_city["municipio"].apply(generate_slug)
        df["city"] = df["city"].apply(generate_slug)

        df["latitude"] = df.merge(df_city, left_on="city", right_on="municipio")["latitude"]
        df["longitude"] = df.merge(df_city, left_on="city", right_on="municipio")["longitude"]

        st.map(df, latitude="-14.4923125", longitude=",-63.9636357", zoom=3)


def page():
    st.title("Clientes")

    page: Page = Page()
    setup_session_state_page()
    render_filter_table(page)
    st.json(page, expanded=False)
    display_customers(page)

    display_top_customers()

    display_customers_by_state()

    display_customers_by_city()
