import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { fetchCountryByName } from "../api/countries";

type CountryDetails = {
  name: string;
  population: number;
  capital: string;
  flag: string;
};

function CountryDetails() {
  const { name } = useParams<{ name: string }>();
  const [country, setCountry] = useState<CountryDetails | null>(null);

  useEffect(() => {
    if (name) {
      fetchCountryByName(name).then(setCountry);
    }
  }, [name]);

  if (!country) return <p>Loading...</p>;

  return (
    <div style={{ padding: "2rem" }}>
      <h2>{country.name}</h2>
      <img src={country.flag} alt={country.name} width={160} />
      <p><strong>Capital:</strong> {country.capital}</p>
      <p><strong>Population:</strong> {country.population.toLocaleString()}</p>
    </div>
  );
}

export default CountryDetails;
