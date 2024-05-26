import { useState } from "react";
import { InputText } from "primereact/inputtext";
import { FloatLabel } from "primereact/floatlabel";

function Register() {
  const [firstName, setFirstName] = useState<string>("");
  const [lastName, setLastName] = useState<string>("");
  const [userName, setUserName] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [email, setEmail] = useState<string>("email");
  const [dob, setDob] = useState<string>("");
  const [address, setAddress] = useState<string>("");
  const [address2, setAddress2] = useState<string>("");
  const [city, setCity] = useState<string>("");
  const [provine, setProvice] = useState<string>("");
  const [gender, setGender] = useState<number>(0);
  return (
    <div className="justify-content-center">
      <h1>Register new account</h1>
      <div className="card flex justify-content-center">
        <FloatLabel>
          <InputText
            id="firstName"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
          />
          <label htmlFor="firstName">First Name</label>
        </FloatLabel>
        <FloatLabel>
          <InputText
            id="lastName"
            value={firstName}
            onChange={(e) => setLastName(e.target.value)}
          />
          <label htmlFor="lastName">Last Name</label>
        </FloatLabel>
      </div>
    </div>
  );
}

export default Register;
