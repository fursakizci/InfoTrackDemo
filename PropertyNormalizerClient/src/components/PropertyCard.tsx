import { useState } from "react";
import type { InternalProperty } from "../types/property";
import Modal from "./Modal";
import Input from "./Input";

type Props = {
  data: InternalProperty;
  onEditConfirm?: (volume: string | null, folio: string | null) => void;
};

export default function PropertyCard({ data, onEditConfirm }: Props) {
  const { fullAddress, lotPlan, volumeFolio, status } = data;
  const [isModalOpen, setIsModalOpen] = useState(false);

  const [volume, setVolume] = useState(volumeFolio.volume ?? "");
  const [folio, setFolio] = useState(volumeFolio.folio ?? "");
  const [errors, setErrors] = useState<{ volume?: string; folio?: string }>({});

  const validate = () => {
    const errs: { volume?: string; folio?: string } = {};
    if (volume && !/^\d{1,6}$/.test(volume)) {
      errs.volume = "Volume must be 1–6 digits";
    }
    if (folio && !/^\d{1,5}$/.test(folio)) {
      errs.folio = "Folio must be 1–5 digits";
    }
    setErrors(errs);
    return Object.keys(errs).length === 0;
  };

  const handleConfirm = () => {
    if (!validate()) return;
    onEditConfirm?.(volume || null, folio || null);
    setIsModalOpen(false);
  };

  return (
    <div className="border border-gray-300 rounded-xl p-4 max-w-lg space-y-3 bg-gray-700">
      <h3 className="text-xl font-bold">Property</h3>
      <div>
        <strong>Full address:</strong> {fullAddress || "—"}
      </div>

      <div>
        <strong>Lot/Plan:</strong>{" "}
        {lotPlan?.lot || lotPlan?.plan
          ? `${lotPlan?.lot ?? "—"} / ${lotPlan?.plan ?? "—"}`
          : "—"}
      </div>

      <div>
        <strong>Status:</strong> {status}
      </div>

      <div>
        <strong>Volume/Folio:</strong>{" "}
        {(volumeFolio.volume ?? "—") + " / " + (volumeFolio.folio ?? "—")}
      </div>

      <button className="bg-gray-900" onClick={() => setIsModalOpen(true)}>
        Update
      </button>

      <Modal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)}>
        <h3 className="text-gray-900 mb-3 text-xl font-bold">
          Edit Volume-Folio
        </h3>

        <Input
          label="Volume"
          value={volume}
          maxLength={6}
          onChange={(e) => {
            const val = e.target.value.replace(/\D/g, "");
            setVolume(val);
          }}
          error={errors.volume}
        />

        <Input
          label="Folio"
          value={folio}
          maxLength={5}
          onChange={(e) => {
            const val = e.target.value.replace(/\D/g, "");
            setFolio(val);
          }}
          error={errors.folio}
        />

        <div className="mt-3 flex gap-2">
          <button onClick={handleConfirm}>Confirm</button>
          <button onClick={() => setIsModalOpen(false)}>Close</button>
        </div>
      </Modal>
    </div>
  );
}
