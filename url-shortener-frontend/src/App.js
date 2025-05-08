import React, { useState, useEffect } from 'react';
import {
  Container,
  Box,
  TextField,
  Button,
  Typography,
  Paper,
  Snackbar,
  Alert,
  List,
  ListItem,
  ListItemText,
  IconButton,
} from '@mui/material';
import ContentCopyIcon from '@mui/icons-material/ContentCopy';
import DeleteIcon from '@mui/icons-material/Delete';
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api';

function App() {
  const [url, setUrl] = useState('');
  const [urls, setUrls] = useState([]);
  const [snackbar, setSnackbar] = useState({
    open: false,
    message: '',
    severity: 'success',
  });

  useEffect(() => {
    fetchUrls();
  }, []);

  const fetchUrls = async () => {
    try {
      const response = await axios.get(`${API_BASE_URL}/url`);
      setUrls(response.data);
    } catch (error) {
      setSnackbar({
        open: true,
        message: 'URL\'ler yüklenirken bir hata oluştu!',
        severity: 'error',
      });
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post(`${API_BASE_URL}/url`, {
        url: url
      });
      setUrls([response.data, ...urls]);
      setUrl('');
      setSnackbar({
        open: true,
        message: 'URL başarıyla kısaltıldı!',
        severity: 'success',
      });
    } catch (error) {
      setSnackbar({
        open: true,
        message: 'URL kısaltılırken bir hata oluştu!',
        severity: 'error',
      });
    }
  };

  const copyToClipboard = (text) => {
    navigator.clipboard.writeText(text);
    setSnackbar({
      open: true,
      message: 'URL panoya kopyalandı!',
      severity: 'success',
    });
  };

  const deleteUrl = async (id) => {
    try {
      await axios.delete(`${API_BASE_URL}/url/${id}`);
      setUrls(urls.filter(url => url.id !== id));
      setSnackbar({
        open: true,
        message: 'URL silindi!',
        severity: 'info',
      });
    } catch (error) {
      setSnackbar({
        open: true,
        message: 'URL silinirken bir hata oluştu!',
        severity: 'error',
      });
    }
  };

  return (
    <Container maxWidth="md">
      <Box sx={{ my: 4 }}>
        <Typography variant="h3" component="h1" gutterBottom align="center">
          URL Kısaltıcı
        </Typography>
        
        <Paper elevation={3} sx={{ p: 3, mb: 4 }}>
          <form onSubmit={handleSubmit}>
            <TextField
              fullWidth
              label="URL'yi girin"
              variant="outlined"
              value={url}
              onChange={(e) => setUrl(e.target.value)}
              sx={{ mb: 2 }}
            />
            <Button
              fullWidth
              variant="contained"
              color="primary"
              type="submit"
              size="large"
            >
              URL'yi Kısalt
            </Button>
          </form>
        </Paper>

        {urls.length > 0 && (
          <Paper elevation={3} sx={{ p: 3 }}>
            <Typography variant="h6" gutterBottom>
              Kısaltılmış URL'leriniz
            </Typography>
            <List>
              {urls.map((item) => (
                <ListItem
                  key={item.id}
                  secondaryAction={
                    <Box>
                      <IconButton
                        edge="end"
                        onClick={() => copyToClipboard(item.shortUrl)}
                        sx={{ mr: 1 }}
                      >
                        <ContentCopyIcon />
                      </IconButton>
                      <IconButton
                        edge="end"
                        onClick={() => deleteUrl(item.id)}
                      >
                        <DeleteIcon />
                      </IconButton>
                    </Box>
                  }
                >
                  <ListItemText
                    primary={item.shortUrl}
                    secondary={`Orijinal URL: ${item.originalUrl} | Tıklanma: ${item.clicks}`}
                  />
                </ListItem>
              ))}
            </List>
          </Paper>
        )}

        <Snackbar
          open={snackbar.open}
          autoHideDuration={3000}
          onClose={() => setSnackbar({ ...snackbar, open: false })}
        >
          <Alert
            onClose={() => setSnackbar({ ...snackbar, open: false })}
            severity={snackbar.severity}
            sx={{ width: '100%' }}
          >
            {snackbar.message}
          </Alert>
        </Snackbar>
      </Box>
    </Container>
  );
}

export default App; 