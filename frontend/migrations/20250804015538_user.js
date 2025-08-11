/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */

export async function up(knex) {
  return knex.schema.createTable('user', (table) => {
    table.increments('id').primary()
    table.string('username', 30)
    table.string('password', 16)
    table.string('email', 80)
  })
}

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
export async function down(knex) {
  return knex.schema.dropTable('user')
}
