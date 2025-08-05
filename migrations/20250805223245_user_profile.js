/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
export async function up(knex) {
  return knex.schema.createTable('user_profile', (table) => {
    table.integer('user_id')
    table.string('username', 30)
    table.string('display_name', 50)
    table.date('dob')
    table.string('gender')
    table.string('country')
    table.string('native_language')
    table.string('learning_language')
    table.timestamp('created_at').defaultTo(knex.fn.now())
  })
}

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
export async function down(knex) {
  return knex.schema.dropTable('user_profile')
}
