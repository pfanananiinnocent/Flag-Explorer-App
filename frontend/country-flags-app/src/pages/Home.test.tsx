import { render, screen } from "@testing-library/react";
import Home from "./Home";
import * as api from "../api/countries";

jest.mock("../api/countries");

test("renders country flags", async () => {
  (api.fetchCountries as jest.Mock).mockResolvedValue([
    { name: "South Africa", flag: "https://flagcdn.com/w320/za.png" }
  ]);

  render(<Home />);
  const country = await screen.findByText("South Africa");
  expect(country).toBeInTheDocument();
});
