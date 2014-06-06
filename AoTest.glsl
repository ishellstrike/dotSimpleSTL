//version 330 inserted here by shader precompiler

#ifdef _VERTEX_
	uniform mat4 modelview_matrix;            
	uniform mat4 projection_matrix;
	
	in vec3 vertex_position;
	in vec2 vertex_uv;
	in vec3 vertex_normal;
	in float vertex_ao;
	in float square;
	
	out vec3 normal;
	out vec4 position;
	out float ao;
	
	void main(void)	{
		normal = ( modelview_matrix * vec4( vertex_normal, 0 ) ).xyz;
		position = projection_matrix * modelview_matrix * vec4( vertex_position, 1 );
		ao = vertex_ao;
		gl_Position = position;
	}
#endif

#ifdef _FRAGMENT_
	in vec3 normal;
	in vec4 position;
	in float ao;
	
	out vec4 out_frag_color;
	
	void main(void) {
		out_frag_color = vec4( 1-ao,0,0, 1.0 );
	}
#endif
