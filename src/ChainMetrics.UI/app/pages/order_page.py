import pandas as pd
import plotly.express as px
import streamlit as st


from app.http.order_http import get_orders, get_orders_by_purchase_date, get_orders_by_status
from app.types.page import Page
from app.pages.components.page_component import setup_session_state_page, render_filter_table


def display_orders(page: Page):
    if st.button("Buscar Pedidos"):
        customers = get_orders(_filter=page)

        if not customers:
            st.write("Nenhum pedido encontrado.")

        df = pd.DataFrame(customers)
        st.dataframe(df, use_container_width=True)


def display_orders_by_status():
    st.subheader("Pedidos por Status")

    if st.button("Buscar Pedidos por Status"):
        status = get_orders_by_status()

        if not status:
            st.write("Nenhum status encontrado.")

        df = pd.DataFrame(status)
        st.dataframe(df, hide_index=True)

        delivery_total_hours = df.loc[df["status"] == "delivered", "totalDeliveryHours"].iloc[0]
        delivery_quantity = df.loc[df["status"] == "delivered", "quantity"].iloc[0]
        average_delivery_hours = delivery_total_hours / delivery_quantity
        average_delivery_minutes = average_delivery_hours * 60

        st.write("Média de minutos (delivery): ", average_delivery_minutes)


def display_scatter_by_purchase_date():
    st.subheader("Quantidade de Pedidos por Data de Compra")

    if st.button("Buscar Pedidos por Data de Compra"):
        orders = get_orders_by_purchase_date()

        if not orders:
            st.write("Nenhum pedido encontrado.")

        df = pd.DataFrame(orders)
        fig = px.scatter(df, x="purchaseDate", y="quantity", title="Quantidade de Pedidos por Data de Compra")
        st.plotly_chart(fig)


def page():
    st.title("Pedidos")

    page: Page = Page()
    setup_session_state_page()
    render_filter_table(page)
    st.json(page, expanded=False)
    display_orders(page)
    display_orders_by_status()
    display_scatter_by_purchase_date()
