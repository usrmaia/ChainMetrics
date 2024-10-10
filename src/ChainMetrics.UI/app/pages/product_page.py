import pandas as pd
import plotly.express as px
import streamlit as st


from app.http.product_http import get_products, get_products_by_category
from app.types.page import Page
from app.pages.components.page_component import setup_session_state_page, render_filter_table


def display_products(page: Page):
    if st.button("Buscar Produtos"):
        products = get_products(_filter=page)

        if not products:
            st.write("Nenhum produto encontrado.")

        df = pd.DataFrame(products)
        st.dataframe(df, use_container_width=True)


def display_products_by_category(page: Page):
    st.subheader("Buscar Produtos por Categoria")

    if st.button("Buscar Produtos por Categoria"):
        products = get_products_by_category()

        if not products:
            st.write("Nenhum produto encontrado.")

        grid_df, grid_fig, _ = st.columns([3, 2, 1])

        df = pd.DataFrame(products)
        grid_df.dataframe(df, use_container_width=True, hide_index=True)

        fig_prices = px.pie(
            df.head(5),
            title="Top 5 categorias com maior valor de venda:",
            names="category",
            values="totalOrderPrice",
        )
        grid_fig.plotly_chart(fig_prices)

        df_top_profit = df.sort_values("profit", ascending=False).head(10)
        df_top_profit["color"] = df_top_profit["profit"].apply(lambda x: "green" if x > 0 else "red")
        fig_top_profit = px.box(
            df_top_profit,
            x="category",
            y="profit",
            title="Top Lucro por Categoria",
            color="color",
        )
        st.plotly_chart(fig_top_profit)

        df_bottom_profit = df.sort_values("profit", ascending=True).head(10)
        df_bottom_profit["color"] = df_bottom_profit["profit"].apply(lambda x: "green" if x > 0 else "red")
        fig_bottom_profit = px.box(
            df_bottom_profit,
            x="category",
            y="profit",
            title="Piso Lucro por Categoria",
            color="color",
        )
        st.plotly_chart(fig_bottom_profit)


def page():
    st.title("Produtos")

    page: Page = Page()
    setup_session_state_page()
    render_filter_table(page)
    st.json(page, expanded=False)
    display_products(page)
    display_products_by_category(page)
