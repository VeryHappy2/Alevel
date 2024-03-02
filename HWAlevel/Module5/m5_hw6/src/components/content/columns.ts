import { GridColDef } from "@mui/x-data-grid";

export const columnsUsers: GridColDef[] = [
    {field: 'id', headerName: 'ID', width: 65},
    {field: 'email', headerName: 'Email', width: 200},
    {field: 'first_name', headerName: 'First name', width: 230},
    {field: 'last_name', headerName: 'Last name', width: 230},
    {field: 'avatar', headerName: 'Avatar', width: 230}
];

export const columnsResources: GridColDef[] = [
    {field: 'id', headerName: 'ID', width: 65},
    {field: 'name', headerName: 'Name', width: 230 },
    {field: 'year', headerName: 'Year', width: 230},
    {field: 'color', headerName: 'Color', width: 230 },
    {field: 'pantone_value', headerName: 'Pantone Value', width: 230}
];  

export const columnsPostUser: GridColDef[] = [
    {field: 'id', headerName: 'ID', width: 65},
    {field: 'name', headerName: 'Name', width: 230 },
    {field: 'job', headerName: 'Name', width: 230 },
];  

export const columnsPostUsers: GridColDef[] = [
    {field: 'id', headerName: 'ID', width: 65},
    {field: 'name', headerName: 'Name', width: 230 },
    {field: 'job', headerName: 'Job', width: 230 },
    {field: 'createdAt', headerName: 'Created at', width: 230 },
]