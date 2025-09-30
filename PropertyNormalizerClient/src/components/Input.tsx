import React from "react";

type Props = {
  label: string;
  value: string;
  maxLength: number;
  onChange: React.ChangeEventHandler<HTMLInputElement>;
  error?: string;
  className?: string;
  id?: string;
};

export default function Input({
  label,
  value,
  maxLength,
  onChange,
  error,
  className = "",
  id,
}: Props) {
  const inputId = id ?? label.toLowerCase().replace(/\s+/g, "-");

  return (
    <div className="mb-4">
      <label
        htmlFor={inputId}
        className="block text-sm font-medium text-gray-700 mb-1"
      >
        {label}
      </label>

      <input
        id={inputId}
        type="text"
        value={value}
        maxLength={maxLength}
        onChange={onChange}
        className={`w-full px-3 py-2 border rounded-md bg-white text-black ${className}`}
      />

      {error && <p className="mt-1 text-xs text-red-600">{error}</p>}
    </div>
  );
}
