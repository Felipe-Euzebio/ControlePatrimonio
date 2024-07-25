import AppEnhancedTable from "../../app/components/AppEnhancedTable";

const userColumns= [
  {
    id: 'id', 
    label: 'ID',
    disablePadding: false,
    numeric: false
  },
  {
    id: 'name', 
    label: 'Name',
    disablePadding: false,
    numeric: false
  },
  {
    id: 'email', 
    label: 'Email',
    disablePadding: false,
    numeric: false
  },
  {
    id: 'role', 
    label: 'Role',
    disablePadding: false,
    numeric: false
  },
];

const userRows = [
  { id: 1, name: 'John Doe', email: 'john.doe@example.com', role: 'Admin' },
  { id: 2, name: 'Jane Smith', email: 'jane.smith@example.com', role: 'User' },
  { id: 3, name: 'Mike Johnson', email: 'mike.johnson@example.com', role: 'User' },
  { id: 4, name: 'Emily Davis', email: 'emily.davis@example.com', role: 'Manager' },
  { id: 5, name: 'Sarah Brown', email: 'sarah.brown@example.com', role: 'Admin' },
];

export default function UsersPage() {
  return (
    <>
      {/* <AppTable columns={userColumns} rows={userRows}/>  */}
      <AppEnhancedTable columns={userColumns} rows={userRows} title="Users" />
    </>
  )
}