import numpy as np
import pandas as pd
import streamlit as st

st.write("Hello world")

st.write("Here's our first attempt at using data to create a table:")

df = pd.DataFrame({"first column": [1, 2, 3, 4], "second column": [10, 20, 30, 40]})

st.write(df)

st.write("Using the Pandas Styler object to highlight some elements in the interactive table.")

df = pd.DataFrame(np.random.randn(10, 20), columns=("col %d" % i for i in range(20)))

st.dataframe(df.style.highlight_max(axis=0))

st.write("You can easily add a line chart to your app with st.line_chart().")

chart_data = pd.DataFrame(np.random.randn(20, 3), columns=["a", "b", "c"])

st.line_chart(chart_data)

st.write("With st.map() you can display data points on a map.")

map_data = pd.DataFrame(np.random.randn(1000, 2) / [50, 50] + [37.76, -122.4], columns=["lat", "lon"])

st.map(map_data)

st.write(
    "When you've got the data or model into the state that you want to explore, you can add in widgets like st.slider(), st.button() or st.selectbox()."
)

x = st.slider("x")
st.write(x, "squared is", x * x)

if st.button("Say hello"):
    st.write("Why hello there")

st.text_input("Your name", key="name")
st.session_state.name

st.write("Use checkboxes to show/hide data.")

if st.checkbox("Show dataframe"):
    chart_data = pd.DataFrame(np.random.randn(20, 3), columns=["a", "b", "c"])

    st.line_chart(chart_data)

st.write("Use a selectbox for options.")

df = pd.DataFrame({"first column": [1, 2, 3, 4], "second column": [10, 20, 30, 40]})

option = st.selectbox("Which number do you like best?", df["first column"])

"You selected: ", option

st.write("Layout your app with columns.")

# add_selectbox = st.sidebar.selectbox(
#     'How would you like to be contacted?',
#     ('Email', 'Home phone', 'Mobile phone')
# )

st.write(
    "Streamlit offers several other ways to control the layout of your app. st.columns lets you place widgets side-by-side, and st.expander lets you conserve space by hiding away large content."
)

left_column, right_column = st.columns(2)
left_column.button("Press me!")

with right_column:
    chosen = st.radio("Sorting hat", ("Gryffindor", "Ravenclaw", "Hufflepuff", "Slytherin"))
    st.write(f"You are in {chosen} house!")

st.write("Create a progress bar")

st.write(
    "Use st.image(<path-to-image>) your Streamlit server will access the file and handle the necessary hosting so your app viewers can see it."
)

st.image("static/logo.svg")

import time

"Starting a long computation..."

latest_iteration = st.empty()
bar = st.progress(0)

for i in range(100):
    latest_iteration.text(f"Iteration {i+1}")
    bar.progress(i + 1)
    time.sleep(0.1)

"...and now we're done!"
