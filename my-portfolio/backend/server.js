const express = require('express');
const bodyParser = require('body-parser');
const nodemailer = require('nodemailer');
const cors = require('cors');

const app = express();
const port = 3000;
const fs = require('fs');
const path = require('path');
const morgan = require('morgan');

const accessLogStream = fs.createWriteStream(path.join(__dirname, 'access.log'), { flags: 'a' });
app.use(morgan('combined'));

app.use(bodyParser.json());
app.use(cors());
app.use(morgan('combined', { stream: accessLogStream }));

// Email configuration
const transporter = nodemailer.createTransport({
  service: 'gmail',
  auth: {
    user: 'preksha.rp2001@gmail.com', 
    pass: 'ahilya@123'   
  }
});

app.post('/send-email', (req, res) => {
  const { email, subject, message } = req.body;

  const mailOptions = {
    from: 'preksha.rp2001@gmail.com', 
    to: email,
    subject: subject,
    text: message
  };

  transporter.sendMail(mailOptions, (error, info) => {
    // if (error) {
    //   console.error('Error sending email:', error);
    //   return res.status(500).send('Failed to send email');
    // }
    console.log('Email sent:', info.response);
    res.status(200).send('Email sent successfully');
  });
});

app.listen(port, () => {
  console.log(`Server running on port ${port}`);
});
