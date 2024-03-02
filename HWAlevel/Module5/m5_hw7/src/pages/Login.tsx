import { Box, Button, TextField } from "@mui/material";
import axios from "axios";
import { FC, ReactElement, useState } from "react";
import { IToken } from "../abstractions/token";
import { IUser } from "../abstractions/user";
import React from "react";

interface IError  {
  err: boolean
}



export const Login: FC<any> = (): ReactElement => {
  const [currentEmailErr, setEmailErr] = useState<IError>({err: false});
  const [currentPasswordErr, setPasswordErr] = useState<IError>({err: false})
  const [currentLogError, setLogError] = useState<any>(<div style={{color: 'red'}}></div>);
  const [currentDivToken, setDivToken] = useState<any>(<div style={{color: 'green'}}></div>)
  const [currentSignOut, setSignOut] = useState<any>(null)

  let token: string | null = ''
  let password = '';
  let email = '';
  
  const [currentLogContent, setLogContent] = useState<any>((
    <Box
      component="form"
      style={{
        
          margin: '35px',
          width: '35%',
          display: "flex",
          justifyContent: 'center',
          alignContent: 'center',
          flexDirection: 'column'
        
      }}
    >
      <TextField
        error={currentEmailErr.err}
        id="Email"
        label="Email"
        margin="normal"
        required
        fullWidth
        name="email"
        
        onChange={(event) => {
          if (!event.target.value) {
            setEmailErr((prev) => ({...prev, err: true }) as IError)
            console.log(currentEmailErr)
          } else {
            setEmailErr((prev) => ({...prev, err: false }) as IError)
          }
          email = event.target.value
          
          console.log(email)
          
        }}
      />
      <TextField
        error={currentPasswordErr.err}
        id="Password"
        label='Password'
        margin="normal"
        required
        fullWidth
        name="password"
        onChange={(event) => {
          password = event.target.value
          console.log('password: ' + password)
          if (event.target.value ) {
            setPasswordErr((prev) => ({err: true }) as IError);
            console.log(currentPasswordErr.err)
          } else {
            setPasswordErr((prev) => ({...prev, err: false }) as IError);
          }
        }}
      />
      <Button style={{margin: '10px'}} variant="contained" onClick={async () => postLogin('api/login')}>Log in</Button>
    </Box>
  ));
  
  const postLogin = async (url: string) =>{
    const mainUrl = 'https://reqres.in/'
    let data:  IUser = {
      email: email,
      password: password
    }

    console.log(JSON.stringify(data))

    await axios.post<IToken>(`${mainUrl}${url}`, data)
      .then( (response) =>{
        setLogContent(null)
        console.log('response:' + JSON.stringify(response))
        console.log('token:' + response.data.token)
        token = response.data.token 
      } )
      .then((response) => {
        setDivToken(<div style={{color: 'green'}}>Your token: {token}</div>)
        setSignOut(<Button style={{margin: '10px'}} variant="contained" onClick={async () => signOut()}>Sign out</Button>)
      })
      .catch(err =>{
        setLogError(<div style={{color: 'red'}}>Wrong password or email</div>)
      } )
    
  }

  const signOut = () =>{
    setSignOut(null)
    token = null
    console.log('token: ' + token)
    setDivToken(<div style={{color: 'green'}}>{token}</div>)
    
    setLogContent(
      <Box
        component="form"
        style={{
          
            margin: '35px',
            width: '35%',
            display: "flex",
            justifyContent: 'center',
            alignContent: 'center',
            flexDirection: 'column'
          
        }}
      >
        <TextField
          error={currentEmailErr.err}
          id="Email"
          label="Email"
          margin="normal"
          required
          fullWidth
          name="email"
          
          onChange={(event) => {
            if (!event.target.value) {
              setEmailErr((prev) => ({...prev, err: true }) as IError)
              console.log(currentEmailErr)
            } else {
              setEmailErr((prev) => ({...prev, err: false }) as IError)
            }
            email = event.target.value
            
            console.log(email)
            
          }}
        />
        <TextField
          error={currentPasswordErr.err}
          id="Password"
          label='Password'
          margin="normal"
          required
          fullWidth
          name="password"
          onChange={(event) => {
            password = event.target.value
            console.log('password: ' + password)
            if (event.target.value ) {
              setPasswordErr((prev) => ({err: true }) as IError);
              console.log(currentPasswordErr.err)
            } else {
              setPasswordErr((prev) => ({...prev, err: false }) as IError);
            }
          }}
        />
        <Button style={{margin: '10px'}} variant="contained" onClick={async () => postLogin('api/login')}>Log in</Button>
      </Box>
    );
  }
  
  
  return (
    <>
      <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>           
        {currentLogContent}
      </div>
      <Box>
        {currentDivToken}
        {currentLogError}
        {currentSignOut}
      </Box>
    </>  
    );
}


