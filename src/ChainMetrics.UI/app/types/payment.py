from pydantic import BaseModel, Field


class Payment(BaseModel):
    order_id: str = Field(..., alias="orderId")
    sequential: int = Field(..., alias="sequential")
    type: str = Field(..., alias="type")
    installments: int = Field(..., alias="installments")
    value: float = Field(..., alias="value")

class PerTypeDTO(BaseModel):
    type: str = Field(..., alias="type")
    quantity: int = Field(..., alias="quantity")
    average_installments: float = Field(..., alias="averageInstallments")
    total_value: float = Field(..., alias="totalValue")
