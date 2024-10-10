import pandas as pd
import plotly.express as px
import streamlit as st

from app.http.payment_http import get_payments, get_payments_by_installments, get_payments_by_type
from app.types.page import Page
from app.pages.components.page_component import setup_session_state_page, render_filter_table


def display_payments(page: Page):
    if st.button("Buscar Pagamentos"):
        payments = get_payments(_filter=page)

        if not payments:
            st.write("Nenhum pagamento encontrado.")

        df = pd.DataFrame(payments)
        st.dataframe(df, use_container_width=True)


def display_payments_by_type():
    st.subheader("Buscar Pagamentos por Tipo")

    if st.button("Buscar Pagamentos por Tipo"):
        payments = get_payments_by_type()

        if not payments:
            st.write("Nenhum pagamento encontrado.")

        grid_df, grid_fig, _ = st.columns([3, 2, 1])

        df = pd.DataFrame(payments)
        grid_df.dataframe(df, use_container_width=True, hide_index=True)

        fig = px.pie(df, names="type", values="totalValue", title="Distribuição de Pagamentos")
        grid_fig.plotly_chart(fig)


def display_scatter_by_isntallments():
    st.subheader("Distribuição de Pagamentos por Parcelas")

    if st.button("Buscar Pagamentos por Parcelas"):
        payments = get_payments_by_installments()

        if not payments:
            st.write("Nenhum pagamento encontrado.")

        df = pd.DataFrame(payments)
        fig = px.scatter(
            df,
            x="quantityInstallments",
            y="averageInstallmentValue",
            labels={
                "quantityInstallments": "Parcelas",
                "averageInstallmentValue": "Valor Médio da Parcela",
            },
        )

        st.dataframe(df, hide_index=True)
        st.plotly_chart(fig)


def page():
    st.title("Pagamentos")

    page: Page = Page()
    setup_session_state_page(sort="orderId")
    render_filter_table(page)
    st.json(page, expanded=False)
    display_payments(page)
    display_payments_by_type()
    display_scatter_by_isntallments()
