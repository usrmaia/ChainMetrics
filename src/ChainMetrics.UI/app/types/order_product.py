from pydantic import BaseModel, Field


class OrderProduct(BaseModel):
    order_id: str = Field(..., alias="orderId")
    product_id: str = Field(..., alias="productId")
    seller_id: str = Field(..., alias="sellerId")
    price: float = Field(..., alias="price")
    shipping_charges: float = Field(..., alias="shippingCharges")
