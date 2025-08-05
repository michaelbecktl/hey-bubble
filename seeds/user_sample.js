/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
export async function seed(knex) {
  // Deletes ALL existing entries
  await knex('user').del()
  await knex('user').insert([
    {
      username: 'maya91',
      display_name: 'Maya',
      email: 'maya@heybubble.co.nz',
      dob: null,
      gender: 'Female',
      native_language: 'EN',
      learning_language: 'JP',
    },
    {
      username: 'alicewonder',
      display_name: 'Alice',
      email: 'alice@heybubble.co.nz',
      dob: null,
      gender: 'Female',
      native_language: 'EN',
      learning_language: 'JP',
    },
    {
      username: 'hanamorijp',
      display_name: 'Hana',
      email: 'hana@heybubble.co.nz',
      dob: null,
      gender: 'Female',
      native_language: 'JP',
      learning_language: 'EN',
    },
  ])
}
