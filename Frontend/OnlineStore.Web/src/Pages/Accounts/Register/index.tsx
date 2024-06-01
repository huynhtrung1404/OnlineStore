import { useState } from "react";
import { InputText } from "primereact/inputtext";
import { InputTextarea } from "primereact/inputtextarea";
import { Password } from "primereact/password";
import { Calendar } from "primereact/calendar";
import { RadioButton } from "primereact/radiobutton";
import { Button } from "primereact/button";

function Register() {
  const [firstName, setFirstName] = useState<string>("");
  const [lastName, setLastName] = useState<string>("");
  const [userName, setUserName] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [email, setEmail] = useState<string>("email");
  const [dob, setDob] = useState<Date | null | undefined>(null);
  const [address, setAddress] = useState<string>("");
  const [address2, setAddress2] = useState<string>("");
  const [city, setCity] = useState<string>("");
  const [province, setProvince] = useState<string>("");
  const [gender, setGender] = useState<number>(0);
  return (
    <>
      <h1 className="flex align-item-center justify-content-center">
        Register an account
      </h1>
      <form className="formgrid grid flex align-items-center justify-content-center">
        <div className="field col-12 md:col-6">
          <label htmlFor="firstname6">Firstname</label>
          <InputText
            id="firstname6"
            onChange={(e) => setFirstName(e.target.value)}
            value={firstName}
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-6">
          <label htmlFor="lastname6">Lastname</label>
          <InputText
            onChange={(e) => setLastName(e.target.value)}
            value={lastName}
            id="lastname6"
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12">
          <label htmlFor="address">Address</label>
          <InputTextarea
            onChange={(e) => setAddress(e.target.value)}
            value={address}
            id="address"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12">
          <label htmlFor="address2">Address2</label>
          <InputTextarea
            onChange={(e) => setAddress2(e.target.value)}
            value={address2}
            id="address2"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-6">
          <label htmlFor="city">City</label>
          <InputText
            value={city}
            onChange={(e) => setCity(e.target.value)}
            id="city"
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-3">
          <label htmlFor="province">Province</label>
          <InputText
            value={province}
            onChange={(e) => setProvince(e.target.value)}
            id="province"
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-3">
          <label htmlFor="calendar">Zip</label>
          <Calendar
            id="calendar"
            value={dob}
            onChange={(e) => setDob(e.value)}
            dateFormat="dd/mm/yyyy"
            className="text-base text-color surface-overlay appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-4">
          <label htmlFor="userName">UserName</label>
          <InputText
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            id="userName"
            type="text"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-2">
          <label htmlFor="password">Password</label>
          <Password
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            id="password"
            className="text-base text-color focus:border-primary w-full"
          />
        </div>
        <div className="field col-12 md:col-6">
          <label htmlFor="email">Email</label>
          <InputText
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            id="email"
            type="email"
            className="text-base text-color surface-overlay p-2 border-1 border-solid surface-border border-round appearance-none outline-none focus:border-primary w-full"
          />
        </div>
        <div className="field col-12">
          <p>Gender</p>
          <div className="formgroup-inline">
            <div className="field-radiobutton">
              <RadioButton
                inputId="male"
                name="male"
                value={1}
                onChange={(e) => setGender(e.value)}
                checked={gender === 1}
              />
              <label htmlFor="male">Male</label>
            </div>
            <div className="field-radiobutton">
              <RadioButton
                inputId="female"
                name="female"
                value={2}
                onChange={(e) => setGender(e.value)}
                checked={gender === 2}
              />
              <label htmlFor="female">Female</label>
            </div>
          </div>
        </div>
        <Button icon="pi pi-check" label="Submit" />
        <Button
          className="ml-4"
          icon="pi pi-times"
          label="Cancel"
          severity="danger"
          text
          raised
        />
      </form>
    </>
  );
}

export default Register;
