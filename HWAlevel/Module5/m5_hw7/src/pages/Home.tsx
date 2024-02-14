import { Box, Typography } from "@mui/material";
import React from "react";
import { FC, ReactElement } from "react";


export const Home: FC<any> = (): ReactElement =>{
    return (
      <>
        <Box
        sx={{
          display: 'flex',
          justifyContent: 'center',
        }}>
          <Typography style={{fontSize: '100px', margin: '10%'}}>
            Welcom to site!
          </Typography>
        </Box>
      </>
    );
  }