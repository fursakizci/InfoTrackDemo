import { render, fireEvent } from "@testing-library/react";
import { describe, it, expect } from "vitest";
import PropertyCard from "../PropertyCard";
import { MOCK_PROPERTY } from "../../mocks/propertyMock";

describe("PropertyCard", () => {
  it("opens and closes modal", () => {
    const { getByText, queryByRole } = render(
      <PropertyCard data={MOCK_PROPERTY} />
    );

    expect(queryByRole("dialog")).toBeNull();

    fireEvent.click(getByText("Update"));
    expect(queryByRole("dialog")).not.toBeNull();

    fireEvent.click(getByText("Close"));
    expect(queryByRole("dialog")).toBeNull();
  });

  it("shows error message when volume is longer than 6 digits", async () => {
    const { getByText, getByLabelText, findByText } = render(
      <PropertyCard data={MOCK_PROPERTY} />
    );

    fireEvent.click(getByText("Update"));

    const volumeInput = getByLabelText("Volume") as HTMLInputElement;
    fireEvent.change(volumeInput, { target: { value: "1234567" } });

    fireEvent.click(getByText("Confirm"));

    expect(await findByText("Volume must be 1–6 digits")).toBeTruthy();
  });
});
