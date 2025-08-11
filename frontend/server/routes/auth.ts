import { Router } from 'express'

const router = Router()

router.get('/', async (req, res) => {
  try {
    res.json('We got no users now')
  } catch (error) {
    console.log('Error obtaining all users', error)
    res.status(500).json({ message: '' })
  }
})

router.post('/register', async (req, res) => {
  try {
    const { username, email, password } = req.body
    // Here you would typically handle user registration logic, such as saving the user to a database
    res
      .status(201)
      .json({ message: 'User registered successfully', username, email })
  } catch (error) {
    console.log('Error registering user', error)
    res.status(500).json({ message: 'Error registering user' })
  }
})

export default router
