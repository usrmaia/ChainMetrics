from pydantic import BaseModel, Field


class Product(BaseModel):
    id: str = Field(..., alias="id")
    category: str = Field(..., alias="category")
    weight: float = Field(..., alias="weight")
    length: float = Field(..., alias="length")
    height: float = Field(..., alias="height")
    width: float = Field(..., alias="width")


class PerCategoryDTO(BaseModel):
    category: str = Field(..., alias="category")
    quantity_products: int = Field(..., alias="quantityProducts")
    total_order_price: float = Field(..., alias="totalOrderPrice")
