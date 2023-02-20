



export default function Register() {

    return (
        <div className='register' style={{ display: 'flex', justifyContent: "center", alignItems: "center", flexDirection: "column", border: "solid 1px red" }}>
            <h1>Register</h1>
            <form>
                <input type="text" placeholder="Name" />
                <input type="text" placeholder="Email" />
                <input type="text" placeholder="Password" />
                <button type="submit">Submit</button>
            </form>
        </div>
            );
};