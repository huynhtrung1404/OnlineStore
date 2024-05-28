import React, { useState } from "react";
import { InputText } from "primereact/inputtext";
import { InputTextarea } from "primereact/inputtextarea";

function Register() {
  const [firstName, setFirstName] = useState<string>("");
  const [lastName, setLastName] = useState<string>("");
  // const [userName, setUserName] = useState<string>("");
  // const [password, setPassword] = useState<string>("");
  // const [email, setEmail] = useState<string>("email");
  // const [dob, setDob] = useState<string>("");
  // const [address, setAddress] = useState<string>("");
  // const [address2, setAddress2] = useState<string>("");
  // const [city, setCity] = useState<string>("");
  // const [provine, setProvice] = useState<string>("");
  // const [gender, setGender] = useState<number>(0);
  return (
    <div className="flex justify-content-center" style={{ maxWidth: "500px" }}>
      <h1 className="flex align-item-center justify-content-center">
        Register an account
      </h1>
      <div className="formgrid grid flex align-items-center justify-content-center">
        <div className="field col-12 md:col-6">
          <label htmlFor="firstname6">Firstname</label>
          <InputText
            id="firstname6"
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-6">
          <label htmlFor="lastname6">Lastname</label>
          <InputText
            id="lastname6"
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12">
          <label htmlFor="address">Address</label>
          <InputTextarea
            id="address"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-6">
          <label htmlFor="city">City</label>
          <InputText
            id="city"
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-3">
          <label htmlFor="state">State</label>
          <InputText
            id="state"
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-3">
          <label htmlFor="zip">Zip</label>
          <InputText
            id="zip"
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
      </div>
    </div>
  );
}

export default Register;
