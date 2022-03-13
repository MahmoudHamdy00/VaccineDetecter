import logo from './logo.svg';
import './App.css';
import Sticky from 'react-sticky-el';
import background from "./assessts/images/background.jpg";
import alfascan from "./assessts/images/alfascan.jpg";
import { findByLabelText } from '@testing-library/dom';
function App() {
  
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
<h1 class= "headerStyle1" style={{fontStyle:'italic'}}>
  Vaccine Recommendation
  </h1>
  <h2  class= "headerStyle2"> 
  Do not know what is the vaccine type that is suitable for you ? 
  </h2>
  <h1 class="headerStyle2">
    we have got your back ..
  </h1>
  <p class="headerStyle2" style={{color:'darkblue' ,fontStyle:'oblique'}}>
    With our claboration with alfa scan,
    we will recommend you the most suitable vaccine type depending on 
    the required blood tests.
  </p>

      <img class="sticky" src={alfascan} alt="Avatar" height="150px" />
      <div style={{ justifyContent:'center',display:'flex'}} >

      <form class="inputs">
      <label for="inputEmail" class="form-label">Email : </label>
      <input type="email" id="inputEmail" class="form-control"  />

      <label for="inputAge" class="form-label">Age :</label>
      <input type="text" id="inputAge" class="form-control"  />

      <div class="input-group mb-3" style={{marginTop:'50px'}}>
      <label class="input-group-text" for="inputGroupSelect01">Gender</label>
      <select class="form-select" id="inputGroupSelect01">
        <option selected>Choose...</option>
        <option value="Male">Male</option>
        <option value="Female">Female</option>
      </select>
</div>
      <label for="inputwbc" class="form-label">White blood cells :</label>
      <input type="text" id="inputwbc" class="form-control"  />
     

      <br></br>
      <label for="inputrbc" class="form-label">Red blood cells :</label>
      <input type="text" id="inputrbc" class="form-control"  />

      <p style={{color:'purple' ,fontStyle:'italic'}}>
        tests not available? register with extra discount
        <br></br>
      <a href='https://www.alfalaboratory.com/'  class="btn btn-danger">
        Register
      </a>
      </p>
      
  
  <button type="submit" class="btn btn-primary">Submit</button>
</form>
</div>
<footer class="site-footer"><div class="container">
  <a id="scroll-up" href="#"><i class="fa fa-angle-up"></i></a>
  <div class="row">
    <div class="col-md-4 col-sm-4">
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
