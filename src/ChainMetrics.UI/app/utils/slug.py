import re

from unidecode import unidecode


def generate_slug(title: str) -> str:
    slug = unidecode(title)  # Substitui caracteres acentuados por caracteres não acentuados
    slug = slug.replace("ç", "c")
    slug = slug.lower()
    slug = re.sub(r"\s+-\s+", "-", slug)  # Substitui espaços seguidos por hífens por um único hífen
    slug = re.sub(r"\s+", "-", slug)  # Substitui espaços por hífens
    slug = re.sub(r"[^\w\-]", "", slug)  # Remove caracteres especiais
    return slug