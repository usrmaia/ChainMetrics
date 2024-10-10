from datetime import date
from pydantic import BaseModel, Field


class Order(BaseModel):
    id: str = Field(..., alias="id")
    customer_id: str = Field(..., alias="customerId")
    status: str = Field(..., alias="status")
    purchase_timestamp: date = Field(..., alias="purchaseTimestamp")
    approved_at: date = Field(..., alias="approvedAt")
    delivered_timestamp: date = Field(..., alias="deliveredTimestamp")
    estimated_delivery_date: date = Field(..., alias="estimatedDeliveryDate")

class PerStatusDTO(BaseModel):
    status: str = Field(..., alias="status")
    quantity: int = Field(..., alias="quantity")
    total_delivery_hours: float = Field(..., alias="totalDeliveryHours")
