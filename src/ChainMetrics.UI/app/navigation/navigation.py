import streamlit as st

from app.pages.about_page import page as about_page
from app.pages.customer_page import page as customer_page
from app.pages.order_page import page as order_page
from app.pages.paymemt_page import page as paymemt_page
from app.pages.product_page import page as product_page


def navigation():
    pg = st.navigation(
        pages=[
            st.Page(
                page=paymemt_page,
                title="Pagamentos",
                icon=":material/payments:",
                url_path="pagamentos",
            ),
            st.Page(
                page=customer_page,
                title="Clientes",
                icon=":material/group:",
                url_path="clientes",
            ),
            st.Page(
                page=order_page,
                title="Pedidos",
                icon=":material/shopping_cart:",
                url_path="pedidos",
            ),
            st.Page(
                page=product_page,
                title="Produtos",
                icon=":material/store:",
                url_path="produtos",
            ),
            st.Page(
                page=about_page,
                title="Sobre",
                icon=":material/info:",
                url_path="sobre",
                default=True,
            ),
        ],
        position="sidebar",
    )

    pg.run()
