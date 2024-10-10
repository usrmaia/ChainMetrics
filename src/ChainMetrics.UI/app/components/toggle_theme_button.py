import streamlit as st


def init_theme():
    if "themes" in st.session_state:
        return
    themes = {
        "current_theme": "dark",
        "light": {
            "theme.base": "dark",
            "theme.backgroundColor": "black",
        },
        "dark": {
            "theme.base": "light",
            "theme.backgroundColor": "white",
        },
    }
    st.session_state.themes = themes


def get_theme():
    init_theme()
    return st.session_state.themes["current_theme"]


def toggle_theme():
    init_theme()
    current_theme = st.session_state.themes["current_theme"]
    new_theme = "dark" if current_theme == "light" else "light"
    st.session_state.themes["current_theme"] = new_theme
    [st._config.set_option(vkey, vval) for vkey, vval in st.session_state.themes[new_theme].items()]
    st.rerun()


def toggle_theme_button():
    init_theme()
    label = "🌜" if st.session_state.themes["current_theme"] == "light" else "🌞"
    st.button(label=label, on_click=toggle_theme)
