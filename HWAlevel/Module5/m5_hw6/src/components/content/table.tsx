import { DataGrid} from '@mui/x-data-grid';
import { IUser } from '../../abstractions/user';
import { IResource } from '../../abstractions/resource';
import { columnsPostUsers, columnsResources, columnsUsers } from './columns';
import { IPostUser } from '../../abstractions/post_user';

export function Table({ users, resources, postUser }: { users: IUser[]; resources: IResource[]; postUser?: IPostUser;}) {
  // const [currentUsers, setUsers] = useState<IUser[]>([])
  // const [currentResources, setResources] = useState<IResource[]>([])
  // const [currentPostUsers, setPostUSer] = useState<any>()

  // useEffect(()=>{
  //   console.log('users' + currentUsers.forEach((item)=>{
  //     console.log(`first_name: ${item.first_name}`)
  //     console.log(`last_name: ${item.last_name}`)
  //   }));
  //   setUsers(users)
  // },[users])

  // useEffect(() => {
  //   console.log('resources:', currentResources);
  //   setResources(resources);
  // }, [resources])

  // useEffect(()=>{
  //   console.log('Post Users:' + postUser);
  //   setPostUSer(postUser)
  // },[postUser])

  // useEffect(()=>{
  //   console.log('currentUsers:' + currentUsers);    
  // },[currentUsers])

  // useEffect(()=>{
  //   console.log('currentResources:' + currentResources);    
  // },[currentResources]) 

  // useEffect(()=>{
  //   console.log('currentPost:' + currentPostUsers);    
  // },[currentPostUsers])
  let checkUsers = null;
  let checkResources = null; 
  let checkPost = null;

  if(users){
    checkUsers = <DataGrid
        style={{margin: '15px'}}
        rows={users}
        columns={columnsUsers}
        initialState={{
          pagination: {
            paginationModel: { page: 0, pageSize: 5 },
          },
        }}
        pageSizeOptions={[5, 10]}
      />
  }

  if(resources){
    checkResources = <DataGrid
    style={{margin: '15px'}}
    rows={resources}
    columns={columnsResources}
    initialState={{
      pagination: {
        paginationModel: { page: 0, pageSize: 5 },
      },
    }}
    pageSizeOptions={[5, 10]}
  />
  } else{
    checkResources = <div>resources not found</div>
  }

  if(postUser){
    console.log(postUser.job)
    checkPost = <DataGrid
        style={{margin: '15px'}}
        rows={[postUser]}      
        columns={columnsPostUsers}
        initialState={{
          pagination: {
            paginationModel: { page: 0, pageSize: 5 },
          },
        }}
        pageSizeOptions={[5, 10]}
      />
  }

  return (
    <>
    <div style={{ height: '400px', width: '100%' }}>
      {checkUsers}
      {checkResources}
      {checkPost}
    </div>
    </>
  );
}
