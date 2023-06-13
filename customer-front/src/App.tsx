import { useEffect, useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";

interface Customer {
  id: number;
  name: string;
  lastName: string;
}

function App() {
  const [customer, setCustomer] = useState<Customer[]>([]);

  useEffect(() => {
    const getCustomer = async () => {
      const response = await fetch("http://localhost:5065/customer");
      const data = (await response.json()) as Customer[];
      console.log(data);

      setCustomer(data);
    };
    getCustomer();
  }, []);

  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Customer Front</h1>
      <div className="card">
        <h2>Customer List</h2>
        {customer.map((item) => (
          <ul>
            <li>
              {item.id} - {item.name} - {item.lastName}
            </li>
          </ul>
        ))}
      </div>
    </>
  );
}

export default App;
