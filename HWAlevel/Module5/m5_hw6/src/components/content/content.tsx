import { ButtonGroup, Button } from '@mui/material';
import { IUser } from '../../abstractions/user';
import { Table } from './table';
import { useEffect, useState } from 'react';
import { IPageUser } from '../../abstractions/page_user';
import axios from 'axios';
import './content'
import { IResource } from '../../abstractions/resource';
import { IPageResource } from '../../abstractions/page_resource';
import { IPostResponceUser, IPostUser } from '../../abstractions/post_user';

export function ContentApp() {
  const [currentusers, setUsers] = useState<IUser[]>([]);
  const [currentResources, setResources] = useState<IResource[]>([]);
  const [currentPost, setPost] = useState<IPostUser>();

  const getApp = (url: string, choise: boolean) => { // choise: true - you choose user. choise: false - you choose resource
    const mainUrl = 'https://reqres.in/';

    if(choise){
      axios.get<IPageUser>(`${mainUrl}${url}`)
        .then(response => {              
          console.log(`data of users: ${JSON.stringify(response.data.data)}`);
          const usersFromResponse: IUser[] = response.data.data
          setUsers(usersFromResponse);               
        })
        .catch(error => {
          console.error('Error:', error);
        });
    }
    else{
      axios.get<IPageResource>(`${mainUrl}${url}`)
        .then(response => {              
          console.log(`data of users: ${JSON.stringify(response.data.data)}`);
          const resourcesFromResponse: IResource[] = response.data.data
          setResources(resourcesFromResponse);               
        })
        .catch(error => {
          console.error('Error:', error);
        });
    }
  }

  const postApp = (url: string, data: IPostResponceUser) => {
    const mainUrl = 'https://reqres.in/';
    axios.post<IPostUser>(`${mainUrl}${url}`, {
      data
    })
    .then((response)=>{
      response.data.job = data.job
      response.data.name = data.name
      setPost(response.data)
    })
    .catch(err => {
      console.log(`Error: ${err}`)
    })
  }

  useEffect(() => {
    console.log(`data users: ${JSON.stringify(currentusers)}`);
  }, [currentusers]);

  useEffect(() => {
    console.log(`data users: ${JSON.stringify(currentResources)}`);
  }, [currentResources]);

  const buttons = {
    display: 'flex',
    justifyContent: 'center',
    margin: '10px',
  };

  let postData : IPostResponceUser = {
    name: 'Angry',
    job: 'developer',    
  }
  
  return (
    <>
      <div style={buttons}>
        <ButtonGroup 
        variant="contained" 
        aria-label="Basic button group">
          <Button onClick={() => getApp('api/users?page=2', true)}>Users</Button>
          <Button onClick={() => getApp('api/unknown', false)}>Resources</Button>
          <Button onClick={() => postApp('api/users', postData)}>Create a new user</Button>
        </ButtonGroup>
      </div>
      <Table users={currentusers} resources={currentResources} postUser={currentPost}/>
    </>
  );
}