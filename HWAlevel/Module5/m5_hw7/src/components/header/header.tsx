import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import LanguageIcon from '@mui/icons-material/Language';
import { Link} from 'react-router-dom';
import { routes } from '../../routes';
import React from 'react';



export function Header() {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar variant="dense">
          <IconButton edge="start" color="inherit" aria-label="menu" sx={{ mr: 2 }}>
            <LanguageIcon />
          </IconButton>
          {routes.map((page) => (
            <Link
              key={page.key}
              to={page.path}
              style={{textDecoration: 'none', marginRight: '15px', color: 'black' }}
            >
              <Typography variant="h6" color="inherit" component="div" textAlign="center">
                {page.title}
              </Typography>
            </Link>
          ))}
        </Toolbar>
      </AppBar>
    </Box>
  );
}
