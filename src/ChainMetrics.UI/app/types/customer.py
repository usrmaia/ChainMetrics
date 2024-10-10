from pydantic import BaseModel, Field

class Customer(BaseModel):
    id: str = Field(..., alias="id")
    zip_code: int = Field(..., alias="zipCode")
    city: str = Field(..., alias="city")
    state: str = Field(..., alias="state")

class PerCustomerDTO(BaseModel):
    customer_id: str = Field(..., alias="customerId")
    total_orders: int = Field(..., alias="totalOrders")
    total_payment_value: int = Field(..., alias="totalPaymentValue")

class PerStateDTO(BaseModel):
    state: str = Field(..., alias="state")
    quantity_orders: int = Field(..., alias="quantityOrders")
    total_payment_value: int = Field(..., alias="totalPaymentValue")

class PerCityDTO(BaseModel):
    city: str = Field(..., alias="city")
    state: str = Field(..., alias="state")
    quantity_purchase: int = Field(..., alias="quantityPurchase")
    total_payment_value: int = Field(..., alias="totalPaymentValue")
