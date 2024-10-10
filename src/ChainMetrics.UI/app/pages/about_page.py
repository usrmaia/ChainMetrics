import streamlit as st


def page():
    st.write(
        """
# Chain Metrics

## Visualização de Dados de Vendas 🔥 Rápido e Simples:

- [**Acompanhamento de Vendas/Pagamentos:**](/pagamentos) Visualize as vendas e pagamentos em tempo real.
- [**Vendas por Cliente:**](/clientes) Visualize as vendas por cliente e aonde estão localizados.
- [**Acompanhamento dos Pedidos:**](/pedidos) Visualize os pedidos em tempo real.
- [**Vendas por Produto:**](/produtos) Visualize as vendas por produto e categoria.

O projeto trabalha com uma API dotnet/aspnet que consome um banco de dados SQLite pré-populado com dados de vendas. A API é consumida por um front-end em Streamlit/Python com pandas e plotly para visualização dos dados.
"""
    )

    st.link_button(label=":black_cat: GitHub", url="https://github.com/usrmaia/ChainMetrics")
