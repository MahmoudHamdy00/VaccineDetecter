import logo from './logo.svg';
import './App.css';
import Sticky from 'react-sticky-el';
import background from "./assessts/images/background.jpg";
import alfascan from "./assessts/images/alfascan.jpg";
import { useState } from 'react';
import { findByLabelText } from '@testing-library/dom';

// constructor(props){
//   super(props)
//   this.onChangeUsername=this.onChangeUsername.bind(this)
//   this.onChangePassword=this.onChangePassword.bind(this)
//   this.onSubmit = this.onSubmit.bind(this);
//   this.state={
//     username:"",
//     password:'',
//      text:[]

//   }
// }



function App() {

  const [userEmail, setUserEmail] = useState("")
  const [userAge, setUserAge] = useState("")
  const [userwbc, setUserwbc] = useState("")
  const [userrbc, setUserrbc] = useState("")
  const [userGender, setUserGender] = useState("")
  function backend(event) {
    //event.preventDefault()
    if (userEmail   ) {
      fetch('https://vaccinedetecter-backend.azurewebsites.net/api/Data/Save', {
        method: 'POST',
        // We convert the React state to SON and send it as the POST body
        body:  JSON.stringify({
          "person": {
            "nationalId": "string",
            "age": userAge,
            "gender": userGender,
            "email": userEmail,
          },
          "test": {
            "whiteBloodCell": userwbc,
            "redBloodCell": userrbc,
            "testDate": "string"
          },
          "message": {
            "messageSubject": "string",
            "messageBody": "last test"
          }
        }),
        

        headers: {
          "Access-Control-Allow-Origin": "*",
          "content-Type": "application/json",
        },


      })
      .then(response => (response.text().then(text => {
        let data;
        try {
          data = text && JSON.parse(text);
        } catch (ex) {
          return Promise.reject(text);
        }
        if (!response.ok) {
          const error = (data && data.message) || response.statusText;
          return Promise.reject(error);
        }
        return data || '';
      })))
      .then(result => alert('your request is submitted '))
      .catch(error => console.log('error', error));

    }
    // fetch('https://vaccinedetecter-backend.azurewebsites.net/api/Email/sendMail')
    //       .then(response => response.json())
    //         .then("ok");
    

    
  }
  function changeEmail(event) {
    setUserEmail(event.target.value)
  }
  function changeAge(event) {
    setUserAge(event.target.value)
  }
  function changewbc(event) {
    setUserwbc(event.target.value)
  }
  function changerbc(event) {
    setUserrbc(event.target.value)
  }
  function changeGender(event) {
    setUserGender(event.target.value)
  }




  return (
    <div style={{
      backgroundImage: `url(${background})`,
      fontSize: '20px',
      height: '100%',
      backgroundSize: 'cover',
      backgroundRepeat: 'no-repeat',
      position: 'relative',
      backgroundAttachment: 'fixed',

    }}>
      <h1 style={{ marginLeft: '20px', color: 'purple', fontStyle: 'italic' }}>
        Vaccine Recommendation
      </h1>
      <h2 style={{ marginLeft: '20px', color: 'crimson', fontStyle: 'oblique' }}>
        Do not know what is the vaccine type that is suitable for you ?
      </h2>
      <h1 style={{ marginLeft: '20px', color: 'crimson', fontStyle: 'oblique' }}>
        we have got your back ..
      </h1>
      <p style={{ marginLeft: '20px', color: 'darkblue', fontStyle: 'oblique' }}>
        With our claboration with alfa scan,
        we will recommend you the most suitable vaccine type depending on
        the required blood tests.
      </p>

      <img class="sticky" src={alfascan} alt="Avatar" height="150px" />
      <div style={{
        justifyContent: 'center',
        display: 'flex'

      }} >
        <form class="inputs">
          <label for="inputEmail" class="form-label" >Email : </label>
          <input type="email" id="inputEmail" class="form-control" onBlur={changeEmail} />

          <label for="inputAge" class="form-label">Age :</label>
          <input type="text" id="inputAge" class="form-control" onBlur={changeAge}/>
          <div class="input-group mb-3" style={{ marginTop: '50px' }}>
            <label class="input-group-text" for="inputGroupSelect01">Gender</label>
            <select class="form-select" id="inputGroupSelect01" onSelect={changeGender}>
              <option selected>Choose...</option>
              <option value="Male">Male</option>
              <option value="Female">Female</option>
            </select>
          </div>
          <label for="inputwbc" class="form-label">White blood cells :</label>
          <input type="text" id="inputwbc" class="form-control" onBlur={changewbc} />


          <br>
          </br>
          <label for="inputrbc" class="form-label">Red blood cells :</label>
          <input type="text" id="inputrbc" class="form-control" onBlur={changerbc} />

          <p style={{ color: 'purple', fontStyle: 'italic' }}>
            tests not available? register with extra discount
            <br></br>
            <a href='https://www.alfalaboratory.com/' class="btn btn-danger">
              Register
            </a>
          </p>


          <button type="submit" class="btn btn-primary" onClick={backend}>Submit</button>
        </form>
      </div>
      <footer class="site-footer"><div class="container">
        <a id="scroll-up" href="#"><i class="fa fa-angle-up"></i></a>
        <div class="row"><div class="col-md-4 col-sm-4">
          <p>Sponsord by Alfa Scan</p>
        </div>
          <div class="col-md-8 col-sm-8">
            <br></br>
            contact us:
            <p marginLeft='100px'>
              vaccineRecommendation@gmail.com
            </p>
          </div>
        </div>
      </div>
      </footer>

    </div>


  );
}

export default App;
