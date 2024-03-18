
import useApiHook from "./Hooks/useApiHook";
import "./App.css";
import { get } from "http";

type Field = {
  id: string;
  villageName: string;
  area: number;
  additionalData: string;
};

const App: React.FC = () => {
  const { data, loading, error } = useApiHook<Field[]>(
    "https://localhost:7138/Fields",
    "GET"
  );

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  if (data) {
    return (
      <div>
        {data.map((field) => (
        <div key={field.id}>
          <h3>{field.villageName}</h3>
          <p>{field.area}</p>
          <p>{field.additionalData}</p>
        </div>
))}

      </div>
    );
  }

  return null;
};

export default App;