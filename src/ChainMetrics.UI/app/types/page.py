from pydantic import BaseModel, Field


class Page(BaseModel):
    page: int = Field(1, alias="Page")
    per_page: int = Field(100, alias="PerPage")
    sort_by: bool = Field(None, alias="SortBy", required=False)
    sort: str = Field(None, alias="Sort", required=False)
    combine_with: bool = Field(None, alias="CombineWith", required=False)

    def model_dump(self, **kwargs):
        return super().model_dump(by_alias=True, **kwargs)
