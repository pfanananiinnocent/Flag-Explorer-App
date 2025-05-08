import { useEffect, useState } from "react";
import { fetchCountries } from "../api/countries";
import { useNavigate } from "react-router-dom";

type Country = {
  name: string;
  flag: string;
};

function Home() {
  const [countries, setCountries] = useState<Country[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchCountries().then(setCountries);
  }, []);

  return (
    <div style={{ display: "grid", gridTemplateColumns: "repeat(auto-fill, minmax(120px, 1fr))", gap: "1rem", padding: "1rem" }}>
      {countries.map((c) => (
        <div key={c.name} onClick={() => navigate(`/country/${c.name}`)} style={{ cursor: "pointer" }}>
          <img src={c.flag} alt={c.name} width={100} />
          <p>{c.name}</p>
        </div>
      ))}
    </div>
  );
}

export default Home;
