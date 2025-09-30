import { useState } from "react";
import PropertyCard from "./components/PropertyCard";
import type { InternalProperty } from "./types/property";
import { MOCK_PROPERTY } from "./mocks/propertyMock";

export default function App() {
  const [prop, setProp] = useState<InternalProperty>(MOCK_PROPERTY);

  return (
    <div className="p-6 flex items-start justify-start min-h-screen">
      <PropertyCard
        data={prop}
        onEditConfirm={(volume, folio) => {
          setProp({
            ...prop,
            volumeFolio: { volume, folio },
            status: volume && folio ? "KnownVolFol" : "UnknownVolFol",
          });
        }}
      />
    </div>
  );
}
